import { Component, OnInit, Input } from '@angular/core';
import { Human } from '../model/human';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { HumanService }  from '../services/human.service';

@Component({
  selector: 'app-human-detail',
  templateUrl: './human-detail.component.html',
  styleUrls: ['./human-detail.component.css']
})
export class HumanDetailComponent implements OnInit {

  @Input() human: Human;
  
  constructor(
    private route: ActivatedRoute,
    private humanService: HumanService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getHuman();
  }

  getHuman(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.humanService.getHuman(id)
      .subscribe(human => this.human = human);
  }

  save(): void {
    this.humanService.updateHuman(this.human)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }
}
