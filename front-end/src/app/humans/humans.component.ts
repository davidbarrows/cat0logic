import { Component, OnInit } from '@angular/core';
import { Human } from '../model/human';
import { HumanService } from '../services/human.service';

@Component({
  selector: 'app-humans',
  templateUrl: './humans.component.html',
  styleUrls: ['./humans.component.css']
})
export class HumansComponent implements OnInit {
  humans: Human[];
  displayedColumns: string[] = ['id', 'fullName', 'firstName', 'lastName', 'deleteHuman'];
  constructor(private humanService: HumanService) { }

  ngOnInit() {
    this.getHumans();
  }

  getHumans(): void {
    this.humanService.getHumans()
      .subscribe(humans => this.humans = humans);
  }

  add(humanFirstName: string, humanLastName: string): void {
    humanFirstName = humanFirstName.trim();
    humanLastName = humanLastName.trim();
    if (!humanFirstName || !humanLastName) { return; }
    let human = new Human();
    human.firstName = humanFirstName;
    human.lastName = humanLastName;
    this.humanService.addHuman(human)
      .subscribe(human => {
        this.humans.push(human);
      });
  }

  delete(human: Human): void {
    this.humans = this.humans.filter(h => h !== human);
    this.humanService.deleteHuman(human).subscribe();
  }
}
