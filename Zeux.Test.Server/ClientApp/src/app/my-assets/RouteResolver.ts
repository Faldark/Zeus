import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, ActivatedRoute } from '@angular/router';
import { Asset } from './my-assets.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { tap, finalize, map } from 'rxjs/operators';
import { of } from 'rxjs';
@Injectable()

export class RouteResolver implements Resolve<any> {

  private assets: Array<Asset>;
  private obsAssets: Observable<Array<Asset>>;
  constructor(private http: HttpClient,

  ) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };


  resolve(route: ActivatedRouteSnapshot) {
    var type = route.params.type;
    if (!this.assets) {
      const uriAsset = '/api/asset/Get/All';
      return this.http.get<Array<Asset>>(uriAsset, this.httpOptions).pipe(map(data => this.assets = data));
    }
    else {
      return of(this.assets.filter(x => type === 'all' ? x : x.assetTypeName === type));
    }


  }

}
