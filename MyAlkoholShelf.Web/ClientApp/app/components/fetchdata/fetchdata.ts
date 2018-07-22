import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import * as $ from "jquery";


@inject(HttpClient)
export class Fetchdata {
    public forecasts: WeatherForecast[];
    public myModalPath : string;
    constructor(http: HttpClient) {
//        http.fetch('api/SampleData/WeatherForecasts')
//            .then(result => result.json() as Promise<WeatherForecast[]>)
//            .then(data => {
//                this.forecasts = data;
//            });
        
    }

    public toggleRow(rowId : string) {
        $('#' + rowId).toggle();
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
