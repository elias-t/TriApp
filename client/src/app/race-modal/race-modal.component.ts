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
  public distinctRaces: string[] = [];
  public selectedRace: Race;
  public currentYear: number;
  public isNewRace: boolean;
  public raceExists: boolean;
  public isEdit: boolean;
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
    this.api.getDistinctRaces().subscribe(data => {
      this.distinctRaces = data;
    });
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    //save race.
    if (!this.isEdit) {
      if (this.isNewRace) {
        this.activeModal.close(this.selectedRace);
      }
      else {
        var sameEvents = this.races.filter((item) => item.name == this.modelRaceName); // get all races with this name
        if (sameEvents.filter((item) => item.year == +this.modelRaceYear).length > 0) //check if selected year already exists.
          this.raceExists = true;
        else {
          this.raceExists = false;
          this.selectedRace.name = this.modelRaceName;
          this.selectedRace.raceFormatId = +sameEvents[0].raceFormatId; //find race format from first of same events.
          this.activeModal.close(this.selectedRace);
        }
      }
    }
    else {
      //TODO - maybe in the future do some extra checks like add.
      this.activeModal.close(this.selectedRace);
    }
  }

  checkIfNewRace(raceVal: any) {
    if (raceVal == "Add new race")
      this.isNewRace = true;
    else
      this.isNewRace = false;
  }
}
