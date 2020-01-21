import { Component, OnInit } from '@angular/core';
import { Human } from '../model/human';
import { HumanService } from '../services/human.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  humans: Human[] = [];

  constructor(private humanService: HumanService) { }

  ngOnInit() {
    this.getHumans();
  }

  getHumans(): void {
    this.humanService.getHumans()
      .subscribe(humans => this.humans = humans.slice(1, 5));
  }
}