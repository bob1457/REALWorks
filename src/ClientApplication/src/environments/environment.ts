// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  weatherApiKey: '5913dc5791f1c134dee45807e4192940', // OpenWeatherMap api
  // weatherApiKey: '3396569b4df442909e0203014190809', // Apixu weather api
  weatherBaseUri: 'https://cors-anywhere.herokuapp.com/https://api.openweathermap.org/data/2.5/weather?id='
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
