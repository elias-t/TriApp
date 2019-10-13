import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { RaceApiService } from '../services/race-api.service';
import { RaceModalComponent } from '../race-modal/race-modal.component';
import { Globals } from '../globals';
import { Race } from '../models/race';
import { Format } from '../models/format';

@Component({
  selector: 'app-triathlonresults',
  templateUrl: './triathlonresults.component.html',
  styleUrls: ['./triathlonresults.component.css']
})

  export class TriathlonresultsComponent implements OnInit {
    public formats: Format[] = [];
    public races: Race[] = [];
    public cacheRaces: Race[] = [];
    public newRace: Race = new Race();


    constructor(private api: RaceApiService, private modal: NgbModal, private globals: Globals) {

    }

    ngOnInit() {
      this.api.getFormats().subscribe(data => {
        this.formats = data;
      });
      this.api.getRaces().subscribe(data => {
        this.races = data;
        this.cacheRaces = this.races;
      });
    }



    filterRaces(filterVal: any) {
      if (filterVal == "0")
        this.races = this.cacheRaces;
      else
        this.races = this.cacheRaces.filter((item) => item.raceFormatName == filterVal);
    }

    public isResultsDisabled(resultsCount: number) {
      if (resultsCount == 0)
        return false;
      return true;
    }

  public addRace() {
    const modalRef = this.modal.open(RaceModalComponent, { size: 'lg', centered: true });
    modalRef.componentInstance.selectedRace = new Race();
    modalRef.componentInstance.isEdit = false;
    modalRef.result.then((result) => {
      console.log('Add New Race - Saved Click : ' + result);
      console.log('Results : ' + result);
      this.api.addRace(result).subscribe((data: Race) => {
        this.newRace = data;
        window.location.reload();
      });
    }, reason => {
      console.log(`Dismissed reason: ${reason}`);
    }).catch((error) => {
      console.log(error);
    });
  }

  public editRace(race: Race) {
    const modalRef = this.modal.open(RaceModalComponent, { size: 'lg', centered: true });
    modalRef.componentInstance.selectedRace = race;
    modalRef.componentInstance.isEdit = true;
    modalRef.result.then((result) => {
      console.log('Edit Existing Race - Saved Click : ' + result);
      console.log('Results : ' + result);
      this.api.addRace(result).subscribe((data: Race) => {
        this.newRace = data;
        window.location.reload();
      });
    }, reason => {
      console.log(`Dismissed reason: ${reason}`);
    }).catch((error) => {
      console.log(error);
    });
  }
}

