import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { RaceApiService } from '../services/race-api.service';
import { Globals } from '../globals';
import { ResultsModalComponent } from '../results-modal/results-modal.component';
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


  constructor(private route: ActivatedRoute, private api: RaceApiService, private modal: NgbModal, private globals: Globals) {
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

}
