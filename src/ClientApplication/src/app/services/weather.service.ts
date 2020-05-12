import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  apiKey = environment.weatherApiKey;

  baseUri = environment.weatherBaseUri;

  constructor(private http: HttpClient) { }

  getWeather(city: string) {
    debugger;

    // var city = {

    // };

    let cityId: string = ''; // '6159905';

    const uri = this.baseUri;

    switch (city) {
      case 'Surrey':
        cityId = '6159905'
        break;
      case 'Vancouver':
        cityId = '6173331'
        break;
      case 'Surrey':
        cityId = '6159905'
        break;
      case 'Burnaby':
        cityId = '5911606'
        break;
      case 'North Vancouver':
        cityId = '6090786'
        break;
      case 'New Westminster':
        cityId = '6087844'
        break;
      case 'Langley':
        cityId = '6049429'
        break;
      case 'Richmond':
        cityId = '6122077'
        break;
      case 'Coquitlam':
        cityId = '5927689'
        break;

      default:
        break;
    }

    console.log(cityId);

    return this.http.get(`${uri}${cityId}&appid=${this.apiKey}`); // Surrey, CA

    // tslint:disable-next-line:max-line-length
    // return this.http.get(`https://api.openweathermap.org/data/2.5/weather?id=${cityId}&appid=${this.apiKey}`)

  }


}
