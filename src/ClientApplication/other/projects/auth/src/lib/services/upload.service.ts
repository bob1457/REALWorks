import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  API_BASE_URL = 'https://localhost:44336';

  url = 'https://localhost:44336/api/Profile/avatar/update';

  constructor(private httpClient: HttpClient) { }

  public uploadFile(file:File, userName: string): Observable<HttpEvent<[]>> {

    const formData = new FormData();
    formData.append('files', file, file.name);
    formData.append('UserName', userName);

    const options = {
      reportProgress: true
    };

    const req = new HttpRequest(
      'POST',
      `${this.url}`,
      formData,
      options
    );

    return this.httpClient.request(req);
  }


}
