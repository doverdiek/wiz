import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import  { environment } from '../../../environments/environment';
import { AuthEndPoints } from '../const';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

export class BaseService {

  hostname : string;
  port : number;

  constructor(private http: HttpClient){
  }

  get(api: AuthEndPoints): Observable<HttpResponse<any>>{
		return this.http.get(`${this.hostname}/${api}`, { observe: 'response'});
  }

  post(api: AuthEndPoints, params: any): Observable<any>{
    return this.http.post<any>(`${this.hostname}/${api}`, params, httpOptions);
  }

  delete(api: AuthEndPoints, params: any): Observable<any>{
    console.warn(params);
    return this.http.delete<any>(`${this.hostname}/${api}/${params}`);
  }
}
