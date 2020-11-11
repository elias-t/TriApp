import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { RaceApiService } from '../services/race-api.service';
import { TriathloncalculatorComponent } from '../triathloncalculator/triathloncalculator.component';
import { ResultsModalComponent } from '../results-modal/results-modal.component';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { Result } from '../models/result';

@Component({
  selector: 'app-viewresults',
  templateUrl: './viewresults.component.html',
  styleUrls: ['./viewresults.component.css']
})
export class ViewresultsComponent implements OnInit {

  public raceid: number;
  public raceResults: Result[] = [];
  public todayYear: number;
  public isDelete: boolean;
  


  constructor(private route: ActivatedRoute, private api: RaceApiService, private modal: NgbModal, private calc: TriathloncalculatorComponent) {
    this.raceid = this.route.snapshot.params.id;
    this.todayYear = new Date().getFullYear();

  }

  ngOnInit() {
    this.api.getRaceById(this.raceid).subscribe(data => {
      this.raceResults = data;
    });
  }

  public updateResult(athleteResult: Result) {
    const modalRef = this.modal.open(ResultsModalComponent, { size: 'lg', centered: true });
    modalRef.componentInstance.selectedResult = athleteResult;
    modalRef.result.then((result) => {
      console.log('update result to athlete,race: ' + result);
      console.log('Results : ' + result);
      this.api.updateResult(result).subscribe((data: Result) => {
        window.location.reload();
      });
    }, reason => {
      console.log(`Dismissed reason: ${reason}`);
    }).catch((error) => {
      console.log(error);
    });
  }

  public deleteResult(athleteResult: Result) {
    const modalConfirmation = this.modal.open(ConfirmationDialogComponent);
    modalConfirmation.componentInstance.modalTitle = 'Delete result entry?';
    modalConfirmation.componentInstance.message = 'Are you sure you like to delete this result entry permanently?';
    modalConfirmation.componentInstance.isDelete = true;
    modalConfirmation.result.then((result) => {
      this.api.deleteResult(+athleteResult.resultId).subscribe(() => {
        window.location.reload();
      });
    }, reason => {
      console.log(`Dismissed reason: ${reason}`);
    }).catch((error) => {
      console.log(error);
    });
  }

  public details(athleteResult: Result) {
    const modalConfirmation = this.modal.open(ConfirmationDialogComponent);
    modalConfirmation.componentInstance.modalTitle = 'Result details';
    modalConfirmation.componentInstance.isDelete = false;
    modalConfirmation.componentInstance.detailsMessage =
      'Swim:  ' + athleteResult.timeSwimStr + " - pace: " + this.calc.calculatePace("swim", athleteResult.timeSwimStr, this.raceResults[0].resultRace.distanceSwim ) + "/100m" + "\n" +
      'T1:    ' + athleteResult.timeT1Str + "\n" + 
    'Bike:  ' + athleteResult.timeBikeStr + " - pace: " + this.calc.calculatePace("bike", athleteResult.timeBikeStr, this.raceResults[0].resultRace.distanceBike) + "km/h" + "\n" +
      'T2:    ' + athleteResult.timeT2Str + "\n" +
    'Run:   ' + athleteResult.timeRunStr + " - pace: " + this.calc.calculatePace("run", athleteResult.timeRunStr, this.raceResults[0].resultRace.distanceRun) + "min/km " + "\n" +
      'Total: ' + athleteResult.timeTotalStr + "\n"; +
    modalConfirmation.result.then((result) => {
      this.api.deleteResult(+athleteResult.resultId).subscribe(() => {
        window.location.reload();
      });
    }, reason => {
      console.log(`Dismissed reason: ${reason}`);
    }).catch((error) => {
      console.log(error);
    });
  }
}
