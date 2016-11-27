import { Component, OnInit, ViewChildren,QueryList,ContentChildren} from '@angular/core';
import {Event} from '../event';
import {EventService} from '../event.service';
import {WeekComponent} from './week/week.component'
import {AuthenticationService} from '../authentication.service'

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],
  
})
export class EventComponent implements OnInit {
  results: Array<Event>;
  weekResults: Array<Event>;
  loggedIn = false;

  @ViewChildren(WeekComponent)
    viewChildren: QueryList<WeekComponent>;

  constructor(private eventService: EventService, private user: AuthenticationService) {}

  ngOnInit() {
  	this.getAllEvents();
    this.loggedIn = this.user.isLoggedIn();
  }

  getAllEvents(): void {
    // this.eventService.getAll().subscribe(
    //       data => { this.results = data; },
    //       error => console.log(error)
    //       );

    this.eventService.getAll()
      .then(data => this.results = data);
     
  }

  loadPrevWeek(){
    this.viewChildren.toArray().forEach((child) => child.previous());
  }

  loadNextWeek(){
    this.viewChildren.toArray().forEach((child) => child.next());
  }

  getWeek() {
    var curr = new Date;
    var firstday = new Date(curr.setDate(curr.getDate() - curr.getDay()));
    var lastday = new Date(curr.setDate(curr.getDate() - curr.getDay()+6));

    console.log(firstday);
    console.log(lastday);
    console.log(this.results.entries);

    // for (let entry of this.results){
    //   if (entry.eventFrom >= firstday && entry.eventFrom < lastday){
    //     this.weekResults.push(entry);
    //     console.log("adding" + entry.eventId);
    //   }
    // }
  }
}
