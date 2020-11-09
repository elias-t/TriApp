import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbTimeStruct } from '@ng-bootstrap/ng-bootstrap';
import { RaceApiService } from '../services/race-api.service';
import { Result } from '../models/result';

@Component({
  selector: 'app-results-modal',
  templateUrl: './results-modal.component.html',
  styleUrls: ['./results-modal.component.css']
})
export class ResultsModalComponent implements OnInit {

  public selectedResult: Result;
  public timeSwim: NgbTimeStruct;
  public timeT1: NgbTimeStruct;
  public timeBike: NgbTimeStruct;
  public timeT2: NgbTimeStruct;
  public timeRun: NgbTimeStruct;
  public timeTotal: NgbTimeStruct;

  constructor(private api: RaceApiService, public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    this.activeModal.close(this.selectedResult);
  }

}
