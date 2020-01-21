import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Human } from '../model/human';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const humans = [
      { id: 11, firstName: 'Robert', lastName: 'Pfeiffer' },
      { id: 12, firstName: 'Michael', lastName: 'Searl' },
      { id: 13, firstName: 'Sophie', lastName: 'Alloway' },
      { id: 14, firstName: 'Dan', lastName: 'Spanner' },
      { id: 15, firstName: 'Kevin', lastName: 'Davey' },
      { id: 16, firstName: 'Gene', lastName: 'Calderazzo' },
      { id: 17, firstName: 'Oli', lastName: 'Hayhurst' },
      { id: 18, firstName: 'Maciek', lastName: 'Pysz' },
      { id: 19, firstName: 'Jessica', lastName: 'Lauren' },
      { id: 20, firstName: 'Stevan', lastName: 'Karkovic' },
      { id: 21, firstName: 'Iain', lastName: 'Hornal' },
      { id: 22, firstName: 'Phoebe', lastName: 'Katis' }  
    ];
    return {humans};
  }

  // Overrides the genId method to ensure that a human always has an id.
  // If the humans array is empty,
  // the method below returns the initial number (11).
  // if the humans array is not empty, the method below returns the highest
  // human id + 1.
  genId(humans: Human[]): number {
    return humans.length > 0 ? Math.max(...humans.map(human => human.id)) + 1 : 11;
  }
}