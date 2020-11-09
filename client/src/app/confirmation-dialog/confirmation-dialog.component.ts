import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {

  public modalTitle: string;
  public message: string;
  public detailsMessage: string;
  public isDelete: boolean;
  

  constructor(public confirmationDialog: NgbActiveModal) { }

  ngOnInit() {
  }

}
