import { Component } from '@angular/core';
import { CardSettingsModel, SwimlaneSettingsModel } from '@syncfusion/ej2-angular-kanban';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { map } from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  title = 'RamSoft.CodingTest.WebApp.Angular';

  public data: Object[] ;  
    public cardSettings: CardSettingsModel = {
      headerField: 'taskId',
      contentField: 'description'        
    };
    

    constructor(private http: HttpClient) { }

    ngOnInit() {
      this.http.get('https://ramsoftcodingtestapi20230703130551.azurewebsites.net/scrumtask').subscribe(result => {  
        this.data = result as Object[];
      })
    }  
}
