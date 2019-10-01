import { Component, OnInit } from '@angular/core';

import { Format } from '../models/format';

@Component({
  selector: 'app-triathloncalculator',
  templateUrl: './triathloncalculator.component.html',
  styleUrls: ['./triathloncalculator.component.css']
})

export class TriathloncalculatorComponent {
  public totalTime: number = 0;
  public totalTimeString: string = "";
  public selectRace = "Select event";
  public swim: number = 0;
  public inputSwim: string = "";
  public inputT1: string = "";
  public inputBike: string = "";
  public inputT2: string = "";
  public inputRun: string = "";
  public races: Format[] = [
    { formatId:1, name: "Sprint", swim: 0.75, bike: 20, run: 5 },
    { formatId:2, name: "Olympic", swim: 1.5, bike: 40, run: 10 },
    { formatId:3, name: "70.3", swim: 1.9, bike: 90, run: 21.1 },
    { formatId:4, name: "140.6", swim: 3.8, bike: 180, run: 42.2 }
  ];
  public selectedRace: Format[];

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
