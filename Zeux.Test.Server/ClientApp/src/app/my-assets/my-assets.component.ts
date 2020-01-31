import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-my-assets',
  templateUrl: './my-assets.component.html',
  styleUrls: ['./my-assets.component.scss']
})
export class MyAssetsComponent implements OnInit {

  private type: string;
  private assetTypes: Array<AssetType>;
  private assets: Array<Asset>;

  constructor(private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router) { }
    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

  ngOnInit() {
    console.log('inited');
    this.type = this.route.snapshot.params.type;
    // this.reloadAssets();

    const uriAssetTypes = '/api/asset/GetTypes';

    this.http.get<Array<AssetType>>(uriAssetTypes, this.httpOptions)
    .subscribe((dataAssetTypes: Array<AssetType>) => {
        this.assetTypes = dataAssetTypes;
      });


      this.route.data.subscribe((data: { assets: any }) => {
        this.assets = data.assets;
        });
    }


  //   this.router.events
  //   .subscribe((event) => {
  //     if (event instanceof NavigationEnd) {
  //       this.reloadAssets();
  //   }});
  // }

  // reloadAssets() {
  //   var type = this.route.snapshot.params.type;
  //   debugger;
  //   if(type === 'all') {
  //     this.route.data.subscribe((data: { assets: any }) => {
  //       this.assets = data.assets;
  //       console.log(data);
  //       });
  //   }
  //   else {
  //     this.route.data.subscribe((data: { assets: Array<Asset> }) => {
  //       this.assets = data.assets.filter(x => x.assetTypeName == type);
  //       });
  //   }
    
  //   // const uriAsset = '/api/asset/Get/' + this.route.snapshot.params.type;
  //   // this.http.get<Array<Asset>>(uriAsset, this.httpOptions)
  //   // .subscribe((dataAssets: Array<Asset>) => {
  //   //       this.assets = dataAssets;
  //   //   });
  // }


  // reloadAssets() {
  //     this.route.data.subscribe((data: { assets: any }) => {
  //       this.assets = data.assets;
  //       });
  //   }
    
    // const uriAsset = '/api/asset/Get/' + this.route.snapshot.params.type;
    // this.http.get<Array<Asset>>(uriAsset, this.httpOptions)
    // .subscribe((dataAssets: Array<Asset>) => {
    //       this.assets = dataAssets;
    //   });
  

}

export class AssetType {
  constructor(
    public id: number,
    public name: string) { }
}

export class Asset {
  constructor(
    public id: number,
    public name: string,
    public percent: number,
    public sum: number,
    public type: AssetType,
    public assetTypeName: string) { }
}
