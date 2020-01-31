import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Asset } from './my-assets.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';
@Injectable()

export class RouteResolver implements Resolve<any> {

  private assets: Array<Asset>;
  constructor(private http: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  resolve(route: ActivatedRouteSnapshot) {
    var type = route.params.type;
    if (!this.assets) {
      return this.http.get<Array<Asset>>('/api/asset/Get/All', this.httpOptions)
      .pipe(map(data => this.assets = data.filter(x => type === 'all' ? x : x.assetTypeName === type)));
    }
    else {
      return of(this.assets.filter(x => type === 'all' ? x : x.assetTypeName === type));
    }
  }
}
