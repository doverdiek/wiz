import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import  { environment } from '../../../environments/environment';
import { AuthEndPoints } from '../const';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  }),
  observe: 'response'
};

export class BaseService {

  hostname : string;

  constructor(private http: HttpClient){
    this.hostname = environment.SERVICE_HOST;
  }

  get(api: AuthEndPoints, servicePoints:string): Observable<HttpResponse<any>>{
		return this.http.get(`${this.hostname}${servicePoints}/${api}`, { observe: 'response'});
  }

  post<T>(api: AuthEndPoints, servicePoints:string, params: any): Observable<any>{
    return this.http.post<T>(`${this.hostname}${servicePoints}/${api}`, params, httpOptions as any);
  }

  delete(api: AuthEndPoints, servicePoints:string, params: any): Observable<any>{
    console.warn(params);
    return this.http.delete<any>(`${this.hostname}${servicePoints}/${api}/${params}`);
  }
}
