import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbDateStruct, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { Athlete } from '../models/athlete';
import { Race } from '../models/race';
import { RaceApiService } from '../services/race-api.service';

@Component({
  selector: 'app-athlete-modal',
  templateUrl: './athlete-modal.component.html',
  styleUrls: ['./athlete-modal.component.css']
})
export class AthleteModalComponent implements OnInit {

  public athletes: Athlete[] = [];
  public selectedAthlete: Athlete;
  public athleteDOB: NgbDateStruct;
  public isNewAthlete: boolean;
  public modalRace: Race;
  city: string ="";
  team: string = "";
  bib: string = "";
  modelAthlete: string;

  constructor(private api: RaceApiService, public activeModal: NgbActiveModal, private parserFormatter: NgbDateParserFormatter) {
  }

  ngOnInit() {
    this.api.getAthletesForRace(+this.modalRace.raceId).subscribe(data => {
      this.athletes = data;
    });
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    if (this.isNewAthlete) {
      this.selectedAthlete.dob = this.parserFormatter.format(this.athleteDOB);
    }
    else {
      this.selectedAthlete = this.athletes.filter((item) => item.athleteId == this.modelAthlete)[0];
    }
    this.selectedAthlete.city = this.city;
    this.selectedAthlete.team = this.team;
    this.selectedAthlete.bib = this.bib;
    this.activeModal.close(this.selectedAthlete);
  }

  checkIfNewAthlete(athleteVal: any) {
    if (athleteVal == "Add new athlete")
      this.isNewAthlete = true;
    else
      this.isNewAthlete = false;
  }
}
