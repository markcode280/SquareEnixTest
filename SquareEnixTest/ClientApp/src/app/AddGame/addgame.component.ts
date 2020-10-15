import { Component, Inject, EventEmitter, Input, Output } from '@angular/core';
import { FetchDataComponent } from '../fetch-data/fetch-data.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game } from '../AddGame/Game'
import { Genre } from '../AddGame/Genre';
import { Platform } from '../AddGame/Platforms';
  
import { Observable, Subscription } from 'rxjs';



@Component({
  selector: 'app-AddGame',
  templateUrl: './addgame.component.html'
})
export class AddGameComp {

  readonly _baseUrl: string;

  fetchData: FetchDataComponent;
  genres: Genre[];
  platforms: Platform[];
 
  visible: boolean = true;

  private eventsSubscription: Subscription;
  private editingSubscription: Subscription;
  private selectedSubscription: Subscription;
  @Output() newGame: EventEmitter<Game> = new EventEmitter();
  @Input() events: Observable<boolean>;
  @Input() selected: Observable<Game>;
  @Input() editing: Observable<boolean>;

  isEditing: boolean = false;

  @Input() game: Game = {
    Name: null,
    Platforms: [],
    Genre: null,
    IsSelected: this.isEditing
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fetch: FetchDataComponent) {
    this._baseUrl = baseUrl;
    this.fetchData = fetch
    http.get<Genre[]>(baseUrl + 'game/GetGenres').subscribe(result => {
    this.genres= result
      //this.addGame.Genres.subscribe(Array.of(this.genre));
      //this.addGame.Genres.emit(this.genre);
    }, error => console.error(error));

    http.get<Platform[]>(baseUrl + 'game/GetPlatforms').subscribe(result => {
      this.platforms = result;
    }, error => console.error(error));
   
  }
  ngOnInit() {

    this.eventsSubscription = this.events.subscribe(() => this.isVisible(this.visible));
    this.editingSubscription = this.editing.subscribe((value) => this.isEditing = value);
    this.selected.subscribe(
      (sentValue) => this.game = sentValue,
      (error) => console.log(error)
    )
  }
  SelectedGame(game: Game): void {
    this.game = this.fetchData.game;
    }
    

  public AddGame(gameObj: Game) {

    this.http.post<Game>(this._baseUrl + 'game', gameObj,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }).subscribe(result => {
        this.game = result;
      }, error => console.error(error));

    this.newGame.emit(this.game);
  }

  public isVisible(evt: boolean) {
    if (this.visible) {
      this.visible = false;
    } else {
      this.visible = true;
    }
  }
  public EditingGame(game: Game) {

    this.isEditing = false;
   
    this.http.put<Game>(this._baseUrl + 'game', game,
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }).subscribe(result => {
        
      }, error => console.error(error));
    this.game = new Game(null, [], null, false);
  }



  

}
