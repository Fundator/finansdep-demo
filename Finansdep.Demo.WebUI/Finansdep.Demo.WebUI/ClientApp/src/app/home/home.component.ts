import { Component, Inject, NgModule } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { PredictionResponse } from './PredictionResponse';
import { PredictionRequest } from './PredictionRequest';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private http;
  private baseUrl;

  public predictions: PredictionResponse[];

  constructor(_http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.http = _http;
    this.baseUrl = _baseUrl;
  }

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<PredictionResponse[]>(baseUrl + 'api/Prediction/PredictMelbourneHousingValue').subscribe(result => {
  //    this.predictions = result;
  //  }, error => console.error(error));
  //}

  onSubmit(predictionRequest: PredictionRequest) {
    this.http.post(this.baseUrl + 'api/Prediction/PredictMelbourneHousingValue', predictionRequest)
      .subscribe(result => {
        console.log(JSON.stringify(result));
        this.predictions = result;
      }
      );
  }
}
