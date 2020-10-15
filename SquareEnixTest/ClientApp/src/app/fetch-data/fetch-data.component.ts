import { Component, Inject, EventEmitter, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game } from '../AddGame/Game';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  games: Game[];
  public game: Game = new Game(null,[],null,false);

 
  eventsSubject: Subject<boolean> = new Subject<boolean>();
  editing: Subject<boolean> = new Subject<boolean>();
  selected: Subject<Game> = new Subject<Game>();
  _http: HttpClient;
  _baseUrl: string

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    http.get<Game[]>(baseUrl + 'game').subscribe(result => {

      this.games = result;

    }, error => console.error(error));

  }

  public AddGame()
  {  
      this.eventsSubject.next();  
  }

  public ModifyGame(game: Game) {
   
    this.game = game;
   
    this.editing.next(true);
    this.selected.next(game);

  }

  public GameRecieved(e)
  {
    this.games.push(e);
  }

  public deleteEntry(game: Game)
  {
    this._http.post<Game>(this._baseUrl + 'game/DeleteGame', game,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }).subscribe(result => {
        if (result) {
         this.games = this.games.filter(item => item!= game);
        }
        //this.forecasts = result;
      }, error => console.error(error));

  }
}



