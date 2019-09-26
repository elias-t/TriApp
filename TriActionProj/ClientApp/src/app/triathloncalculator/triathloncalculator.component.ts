import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { TestModalComponent } from '../test-modal/test-modal.component';


@Component({
  selector: 'app-triathloncalculator',
  templateUrl: './triathloncalculator.component.html',
  styleUrls: ['./triathloncalculator.component.css']
})
//export class TriathloncalculatorComponent implements OnInit {

//  constructor(private modal: NgbModal) { }

//  ngOnInit() {
//  }

//  public AddRace() {
//    const modalRef = this.modal.open(TestModalComponent, { size: 'sm', centered: true });
//    modalRef.result.then((result) => {
//      console.log(result);
//    }).catch((error) => {
//      console.log(error);
//    });
//  }
//}

export class TriathloncalculatorComponent {
  public totalTime: number = 0;
  public totalTimeString: string = "";
  public selectRace = "Select event";
  public selectedRace: Races[1];
  public swim: number = 0;
  public inputSwim: string = "";
  public inputT1: string = "";
  public inputBike: string = "";
  public inputT2: string = "";
  public inputRun: string = "";
  public races: Races[] = [
    { name: "Sprint", swim: 0.75, bike: 20, run: 5 },
    { name: "Olympic", swim: 1.5, bike: 40, run: 10 },
    { name: "70.3", swim: 1.9, bike: 90, run: 21.1 },
    { name: "140.6", swim: 3.8, bike: 180, run: 42.2 }
  ];

  public selectChangeHandler(event: any) {
    //update the ui
    this.selectRace = event.target.value;
    this.selectedRace = (this.races.filter((item) => item.name == this.selectRace)) as any[];
    this.swim = this.selectedRace[0].swim;
  }

  public timeCounter() {

    //var swimTime = angular.element('#swim').val()
    //var swimtime = $scope.swim;
    //var array = this.inputSwim.split(':')[0];
    //totalTime in seconds.
    this.totalTime = this.selectedRace[0].swim * 10 * (parseInt(this.inputSwim.split(':')[0]) * 60 + parseInt(this.inputSwim.split(':')[1]));
    this.totalTime += (parseInt(this.inputT1.split(':')[0]) * 60 + parseInt(this.inputT1.split(':')[1]));
    this.totalTime += this.selectedRace[0].bike / parseInt(this.inputBike) * 3600;
    this.totalTime += (parseInt(this.inputT2.split(':')[0]) * 60 + parseInt(this.inputT2.split(':')[1]));
    this.totalTime += this.selectedRace[0].run * (parseInt(this.inputRun.split(':')[0]) * 60 + parseInt(this.inputRun.split(':')[1]));
    var minutes = this.totalTime / 60;
    var fseconds = Math.floor(this.totalTime % 60);
    var fhours = Math.floor(minutes / 60);
    var fminutes = Math.floor(minutes % 60);
    this.totalTimeString = fhours + " hours, " + fminutes + " minutes, " + fseconds + " seconds";
  }

}


export interface Races {
  [key: string]: any;
  name: string;
  swim: number;
  bike: number;
  run: number;
}
