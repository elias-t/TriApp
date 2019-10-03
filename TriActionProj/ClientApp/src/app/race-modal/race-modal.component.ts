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
  public selectedRace: Race;
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
    this.selectedRace = new Race();
    this.selectedRace.Name = '' + this.modelRaceName;
    this.selectedRace.RaceFormatId = +this.modelRaceFormatId;
    this.selectedRace.Year = +this.modelRaceYear;
    this.activeModal.close(this.selectedRace);
  }

  checkIfNewRace(raceVal: any) {
    if (raceVal == "Add new race")
      this.isNewRace = true;
    else
      this.isNewRace = false;
  }
}
