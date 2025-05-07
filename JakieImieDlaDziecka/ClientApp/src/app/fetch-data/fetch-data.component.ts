import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NamesPerYear } from '../Models/NamesPerYear';
import { Sex } from '../Enums/Sex';
@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public NamesPerYear: NamesPerYear[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<NamesPerYear[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.NamesPerYear = result;
      this.NamesPerYear.forEach(_ => {
        _.sexName = Sex[_.sex]
      })
    }, error => console.error(error));
  }
}
