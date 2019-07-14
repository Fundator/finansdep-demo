import { Component, Inject, NgModule } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { PredictionResponse } from './PredictionResponse';
import { PredictionRequest } from './PredictionRequest';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private http;
  private baseUrl;

  public prediction: PredictionResponse;
  public predictionRequest: PredictionRequest = {
    Suburb: "Essendon",
    Rooms: 2,
    Type: "u",
    Method: "SP",
    PostCode: 3040,
    RegionName: "Western Metropolitan",
    PropertyCount: 9264,
    Distance: 8.8,
    CouncilArea: "Moonee Valley City Council"
  };

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;
  }

  onSubmit(predictionRequest: PredictionRequest) {
    this.http.post(this.baseUrl + 'api/Prediction/PredictHousingValue', predictionRequest)
      .subscribe(result => {
        this.prediction = result;
        this.barChartData = [
          {
            data: [
              result.suburb,
              result.rooms,
              result.type,
              result.method,
              result.postcode,
              result.regionname,
              result.propertycount,
              result.distance,
              result.councilArea,
            ],
            label: 'Feature contribution'
          },
        ];
        console.log(JSON.stringify(this.prediction));
      }
      );
  }

  public barChartData: ChartDataSets[] = [
    { data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0], label: 'Feature contribution' },
  ];

  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: Label[] = [
    'Suburb',
    'Rooms',
    'Type',
    'Method',
    'Post Code',
    'Region Name',
    'Property Count',
    'Distance',
    'Council Area'];
  public barChartType: ChartType = 'horizontalBar';
  public barChartLegend = true;
  public barChartPlugins = [];
}
