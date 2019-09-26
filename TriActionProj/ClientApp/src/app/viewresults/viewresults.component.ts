import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { RaceApiService } from '../services/race-api.service';
import { TestModalComponent } from '../test-modal/test-modal.component';
import { Globals } from '../globals';


@Component({
  selector: 'app-viewresults',
  templateUrl: './viewresults.component.html',
  styleUrls: ['./viewresults.component.css']
})
export class ViewresultsComponent implements OnInit {

  public raceid: number;
  public raceResults: Results[] = [];
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

}

interface Results {
  resultId: number;
  timeSwim: string;
  timeT1: string;
  timeBike: string;
  timeT2: string;
  timeRun: string;
  timeTotal: string;
  resultAthlete: object;
  resultRace: object;
}
