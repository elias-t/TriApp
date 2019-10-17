import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbDateStruct, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { Athlete } from '../models/athlete';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-athlete-modal',
  templateUrl: './athlete-modal.component.html',
  styleUrls: ['./athlete-modal.component.css']
})
export class AthleteModalComponent implements OnInit {

  public selectedAthlete: Athlete;
  public athleteDOB: NgbDateStruct;

  constructor(public activeModal: NgbActiveModal, private parserFormatter: NgbDateParserFormatter) {
  }

  ngOnInit() {
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    this.selectedAthlete.dob = this.parserFormatter.format(this.athleteDOB);
    this.activeModal.close(this.selectedAthlete);
  }

}
