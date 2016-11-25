import { Component, OnInit } from '@angular/core';
import {Event} from '../event';
import {EventService} from '../event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  results: Array<Event>;

  constructor(private eventService: EventService) {}

  ngOnInit() {
  	this.eventService.getAll().subscribe(
  		data => {this.results = data; },
  		error => console.log(error)
  		);
  }
}
