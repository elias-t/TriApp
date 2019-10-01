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
    const modalRef = this.modal.open(RaceModalComponent, { size: 'lg', centered: true });
    //modalRef.result.then((result) => {
    //  console.log('Add New Rota - Saved Click : ' + result);
    //  this.loading = true;
    //  console.log('Results : ' + result);
    //  this.rotaApi.addRota(result, this.weekNumber).subscribe((data: Rota[]) => {
    //    this.listRota = data;
    //  });
    //  this.loading = false;
    //}, reason => {
    //  console.log(`Dismissed reason: ${reason}`);
    //}).catch((error) => {
    //  console.log(error);
    //});
    }
  }
