import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-car-table',
  templateUrl: './car-table.component.html',
  styleUrls: ['./car-table.component.css']
})
export class CarTableComponent implements OnInit {
  cars: any[] = [];

  constructor(private https: HttpClient) { }

  ngOnInit(): void {
    this.https.get('https://localhost:7291/api/Car').subscribe((data: any) => {
      this.cars = data;
    });
  }
}
