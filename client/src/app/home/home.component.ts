import { Component, OnInit } from '@angular/core';
import { IItem } from '../Interfaces/Item';
import { ProductsService } from '../products/products.service';
import {FormGroup , FormControl, Validators, FormBuilder , FormArray} from '@angular/forms'
import * as $ from 'jquery'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  allItems:IItem[]=[];
  itemForm:FormGroup;
  image:FormGroup;


  constructor(private productService:ProductsService , private fb:FormBuilder) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.jqueryTest();
    this.createForm();
  }

  createbasket(){

  }

  createForm(){
    this.itemForm = this.fb.group({
      name:[null,Validators.required],
      price:[null,Validators.required],
      imageUrl:[null,Validators.required],
      Prices: this.fb.array([this.pricesForm()])
    });


  }
  private pricesForm():FormGroup{

    return this.fb.group({
      sizeName:[],
      sizePrice:[]
    })
  }
  //zoraar el add
  addNewPrice(){
    this.Prices.push(this.pricesForm())
  }

  removeContact(index:any){
    this.Prices.removeAt(index)
  }

  get Prices(){
    return this.itemForm.get('Prices') as FormArray;
  }


  formSubmit(){
    console.log(this.itemForm.value);

    this.productService.AddItem(this.itemForm.value).subscribe(res=>{
      console.log(res);
      this.getAllProducts();
      this.clearForm()



    },err=>{
      console.log(err);
    })
  }


  ///IMaages
  uploadPic(target: EventTarget | null ){
    if(!target)return;
    var input = target as HTMLInputElement;
    if(!input.files)return;
    let ImgUrl:string
    this.productService.uploadImaage(input.files[0]).subscribe(res=>{
      console.log(res.url);
      ImgUrl=res.url
      this.itemForm.patchValue({imageUrl:ImgUrl})

    },err=>{
      console.log(err.text);

    })

  }


  ///////////



  editItem(item:IItem){
    console.log('tmam');

    for(let i=0; i < this.Prices.controls.length; i++){
      console.log(this.Prices.controls[i],item.prices[i]);

      this.Prices.controls[i].patchValue(item.prices[i])
    }

    this.itemForm.patchValue(item);
    // this.itemForm = this.fb.group({
    //   name:[item.name,Validators.required],
    //   price:[item.price,Validators.required],
    //   Prices: this.fb.array([...item.prices])
    // });

    // console.log('nset nfsk wl eh',this.Prices.controls[0].value);


    // console.log(this.itemForm.get('Prices')?.value);
    // this.itemForm.get('Prices')?.setValue(item.prices)
    // console.log(item.prices);
    // this.itemForm.patchValue({
    //   name: item.name,
    //   price: item.price,
    //   imageUrl: item.imageUrl,
    // })

    // this.itemForm.get('Prices')?.patchValue(item.prices);

    // this.itemForm.patchValue(item)
    // this.Prices.patchValue(item.prices)

  }

  clearForm(){
    this.itemForm.reset()

  }





  getAllProducts(){
    this.productService.getAllItems().subscribe(res=>{
      this.allItems = res;

    },err=>{
      console.log(err);

    })

  }

  delteItem( id:any){
    this.productService.deleteItemById(id).subscribe(res=>{
      console.log('deleted item',res);
      this.ngOnInit();

    },err=>{
      console.log(err);

    })
  }

  jqueryTest(){
    // var pricesIndex=1;
    // $(document).on('click', '.add-size', function(){
    //     var size = $('div[for="sizes"]:first').clone();

    //     size.find('.add-size').remove();
    //     size.find('.sname').removeAttr("formControlName").attr("formControlName",`sizeName`)
    //     size.find('.sprice').removeAttr("formControlName").attr("formControlName",`sizePrice`)
    //     $('#frmItem .modal-body').append(size);
    //     size.find('.fmgroup').removeAttr("formGroupName").attr("formGroupName",`${pricesIndex}`)
    //     pricesIndex++;
    // });
    // $(document).on('click', '.remove-size', function () {
    //     $(this).closest('div[for="sizes"]').remove();
    // });
  }
}
