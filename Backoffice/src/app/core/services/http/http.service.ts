import { Injectable } from '@angular/core';
import { rootCertificates } from 'tls';
import { ApiMethod, AuthEndPoints } from '../../const';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class HttpServive {

  methods: ApiMethod;

  constructor(
    private http: HttpClient
  ){
  }

  async requestCall(api: AuthEndPoints, method: ApiMethod, data?: any){
    let response;
    switch(method){
      case ApiMethod.GET:
        response = this.http.get(`${environment.SERVICE_HOST}${api}`).toPromise();
        break;
      case ApiMethod.POST:
        response = this.http.post(`${environment.SERVICE_HOST}${api}`, data).toPromise();
        break;
      case ApiMethod.PUT:
        response = this.http.put(`${environment.SERVICE_HOST}${api}`, data).toPromise();
        break;
      case ApiMethod.DELETE:
        response = this.http.delete(`${environment.SERVICE_HOST}${api}`).toPromise();
        break;
    }
  }
}
