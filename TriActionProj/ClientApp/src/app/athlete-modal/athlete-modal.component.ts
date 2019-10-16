import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Athlete } from '../models/athlete';

@Component({
  selector: 'app-athlete-modal',
  templateUrl: './athlete-modal.component.html',
  styleUrls: ['./athlete-modal.component.css']
})
export class AthleteModalComponent implements OnInit {

  public selectedAthlete: Athlete;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    this.activeModal.close(this.selectedAthlete);
  }

}
