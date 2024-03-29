import { Component, OnInit, enableProdMode } from '@angular/core';
import { EventService } from './event.service';
import { EventComponent } from './event/event.component'
import { AuthenticationService } from './authentication.service'
enableProdMode()
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [EventService]
})
export class AppComponent implements OnInit{
  constructor(private authService: AuthenticationService) {}
  title = 'Zenith Society';
  loggedIn = false;
  
  ngOnInit() {
    this.loggedIn = this.authService.isLoggedIn();

  }
}
