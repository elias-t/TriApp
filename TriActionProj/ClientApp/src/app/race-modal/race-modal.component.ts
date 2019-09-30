import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RaceApiService } from '../services/race-api.service';

@Component({
  selector: 'app-race-modal',
  templateUrl: './race-modal.component.html',
  styleUrls: ['./race-modal.component.css']
})
export class RaceModalComponent implements OnInit {

  public formats: Formats[] = [];
  public currentYear: number;

  constructor(private api: RaceApiService, public activeModal: NgbActiveModal,) { }

  ngOnInit() {
    this.currentYear = new Date().getFullYear();
    this.api.getFormats().subscribe(data => {
      this.formats = data;
    });
  }

  btnClose_Clicked() {
    this.activeModal.close();
  }

  btnSave_Clicked() {
    //save race.
    this.activeModal.close();
  }

}

interface Formats {
  formatId: number;
  name: string;
}
