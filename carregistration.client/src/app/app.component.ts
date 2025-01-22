import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CarTableComponent } from './car-table/car-table.component';
import { RegistrationStatusComponent } from './registration-status/registration-status.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  cars: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCars();
  }

  getCars() {
    this.http.get('https://localhost:7291/api/Car').subscribe((data: any) => {
      this.cars = data;
    });

  
  }

  title = 'carregistration.client';
}
