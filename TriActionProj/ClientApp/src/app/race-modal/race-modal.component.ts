import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RaceApiService } from '../services/race-api.service';
import { Format } from '../models/format';
import { Race } from '../models/race';

@Component({
  selector: 'app-race-modal',
  templateUrl: './race-modal.component.html',
  styleUrls: ['./race-modal.component.css']
})
export class RaceModalComponent implements OnInit {

  public formats: Format[] = [];
  public races: Race[] = [];
  public currentYear: number;
  public isNewRace: boolean;
  selectedRace: Race;
  modelRaceName: string;
  modelRaceFormatId: string;
  modelRaceYear: string;

  constructor(private api: RaceApiService, public activeModal: NgbActiveModal,) { }

  ngOnInit() {
    this.currentYear = new Date().getFullYear();
    this.api.getFormats().subscribe(data => {
      this.formats = data;
    });
    this.api.getRaces().subscribe(data => {
      this.races = data;
    });
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    //save race.
    this.selectedRace.name = this.modelRaceName;
    this.selectedRace.raceFormatId = +this.modelRaceFormatId;
    this.selectedRace.year = +this.modelRaceYear;
    this.activeModal.close(this.selectedRace);
  }

  checkIfNewRace(raceVal: any) {
    if (raceVal == "0")
      this.isNewRace = true;
    else
      this.isNewRace = false;
  }
}
