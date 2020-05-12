import { WeatherService } from './../../services/weather.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  public weatherData: any;
  public iconCode = ''; // this.weatherData.weather[0].icon;
  public iconUrl = 'http://openweathermap.org/img/w/' + this.iconCode + '.png';

  constructor(private weatherService: WeatherService) { }

  ngOnInit() {
    debugger;
    // tslint:disable-next-line:max-line-length
    this.weatherService.getWeather('Surrey').subscribe(data => {this.weatherData = data; this.iconCode = this.weatherData.weather[0].icon; });
  }

  getWeather(city:string) {
    debugger;
    this.weatherService.getWeather(city).subscribe(data => {console.log(data); this.weatherData = data; console.log(this.weatherData.name);
    });
  }

}
