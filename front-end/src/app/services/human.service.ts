import { Injectable } from '@angular/core';
import { Human } from '../model/human';
import { Observable, of } from 'rxjs';
import { MessageService } from '../services/message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, count } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HumanService {

  private humansUrl = 'api/humans';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  getHumans(): Observable<Human[]> {
    return this.http.get<Human[]>(this.humansUrl)
      .pipe(
        tap(_ => this.log('fetched humans')),
        catchError(this.handleError<Human[]>(`getHumans`, []))
      );
  }

  /** POST: add a new human to the server */
  addHuman (human: Human): Observable<Human> {
    return this.http.post<Human>(this.humansUrl, human, this.httpOptions).pipe(
      tap((newHuman: Human) => this.log(`added human w/ id=${newHuman.id}`)),
      catchError(this.handleError<Human>('addHuman'))
    );
  }

  /** Log a HumanService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`HumanService: ${message}`);
  }

  getHuman(id: number): Observable<Human> {
    const url = `${this.humansUrl}/${id}`;
    return this.http.get<Human>(url).pipe(
      tap(_ => {
        this.log(`fetched human id=${id}`);
      }),
      catchError(this.handleError<Human>(`getHuman id=${id}`))
    )
  }

  /** PUT: update the human on the server */
  updateHuman (human: Human): Observable<any> {
    return this.http.put(this.humansUrl, human, this.httpOptions).pipe(
      tap(_ => this.log(`updated human id=${human.id}`)),
      catchError(this.handleError<any>('updateHuman'))
    );
  }

  /** DELETE: delete the human from the server */
  deleteHuman (human: Human | number): Observable<Human> {
    const id = typeof human === 'number' ? human : human.id;
    const url = `${this.humansUrl}/${id}`;

    return this.http.delete<Human>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted human id=${id}`)),
      catchError(this.handleError<Human>('deleteHuman'))
    );
  }

  /* GET humans whose lastName contains search term */
  searchHumans(term: string): Observable<Human[]> {
    if (!term.trim()) {
      // if not search term, return empty human array.
      return of([]);
    }
    return this.http.get<Human[]>(`${this.humansUrl}/?lastName=${term}`).pipe(
      tap(_ => {
        const humanCount = _.length;
        this.log(`found ${humanCount} humans matching "${term}"`)
      }),
      catchError(this.handleError<Human[]>('searchHumans', []))
    );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
