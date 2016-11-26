import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class EventService {

  constructor(private http: Http) { }

  getAll() {
    return this.http.get('http://localhost:52377/api/eventsapi')
    .map((res: Response) => res.json());
  }
}
