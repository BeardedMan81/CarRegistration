import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { CarTableComponent } from './car-table/car-table.component';
import { RegistrationStatusComponent } from './registration-status/registration-status.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: CarTableComponent },
  { path: 'registration', component: RegistrationStatusComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CarTableComponent,
    RegistrationStatusComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
