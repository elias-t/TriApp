import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbTimeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TriathloncalculatorComponent } from './triathloncalculator/triathloncalculator.component';
import { FormsModule } from '@angular/forms';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { TriathlonresultsComponent } from './triathlonresults/triathlonresults.component';
import { ViewresultsComponent } from './viewresults/viewresults.component';
import { RaceModalComponent } from './race-modal/race-modal.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { UniqueRacePipe } from './unique-race.pipe';
import { AthleteModalComponent } from './athlete-modal/athlete-modal.component';
import { DatePipe } from '@angular/common';
import { ResultsModalComponent } from './results-modal/results-modal.component';
import { NgbTimeStringAdapterService } from './services/ngb-time-string-adapter.service';

@NgModule({
  declarations: [
    AppComponent,
    TriathloncalculatorComponent,
    NavmenuComponent,
    TriathlonresultsComponent,
    ViewresultsComponent,
    RaceModalComponent,
    ConfirmationDialogComponent,
    UniqueRacePipe,
    AthleteModalComponent,
    ResultsModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [DatePipe, { provide: NgbTimeAdapter, useClass: NgbTimeStringAdapterService }],
  entryComponents: [RaceModalComponent, ConfirmationDialogComponent, AthleteModalComponent, ResultsModalComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
