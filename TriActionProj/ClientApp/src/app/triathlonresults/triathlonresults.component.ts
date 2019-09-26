import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { RaceApiService } from '../services/race-api.service';
import { TestModalComponent } from '../test-modal/test-modal.component';
import { Globals } from '../globals';

@Component({
  selector: 'app-triathlonresults',
  templateUrl: './triathlonresults.component.html',
  styleUrls: ['./triathlonresults.component.css']
})

  export class TriathlonresultsComponent implements OnInit {
    public formats: Formats[] = [];
    public races: Races[] = [];
    public cacheRaces: Races[] = [];

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

    public AddRace() {
      const modalRef = this.modal.open(TestModalComponent, { size: 'xl', centered: true });
      modalRef.result.then((result) => {
        console.log(result);
      }).catch((error) => {
        console.log(error);
      });
    }
  }

  interface Formats {
    formatId: number;
    name: string;
  }

  interface Races {
    raceId: string;
    name: string;
    raceFormatId: number;
    year: number;
    raceFormatName: string;
    resultsCount: number;
  }
