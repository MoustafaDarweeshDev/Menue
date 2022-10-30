import { Component, OnInit  } from '@angular/core';
import { IItem } from '../Interfaces/Item';
import { ProductsService } from '../products/products.service';
import {FormGroup , FormControl, Validators, FormBuilder , FormArray} from '@angular/forms'
import * as $ from 'jquery'
import * as bootstrap from "bootstrap"


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  allItems:IItem[]=[];
  itemForm:FormGroup;
  image:FormGroup;
  isEdit:boolean=false;
  itemToEdit: IItem;


  constructor(private productService:ProductsService , private fb:FormBuilder) { }

  ngOnInit(): void {
    this.getAllProducts();
    this.createForm();

  }


  createForm(){
    this.itemForm = this.fb.group({
      name:[null,Validators.required],
      price:[null,Validators.required],
      imageUrl:[null,Validators.required],
      Prices: this.fb.array([this.pricesForm()])
    });


  }
  //form array methods
  private pricesForm():FormGroup{

    return this.fb.group({
      sizeName:[],
      sizePrice:[]
    })
  }

  addNewPrice(){
    this.Prices.push(this.pricesForm())
  }

  removeContact(index:any){
    this.Prices.removeAt(index)
  }

  get Prices(){
    return this.itemForm.get('Prices') as FormArray;
  }
  set Prices(value:FormArray){
    this.Prices=value;
  }
  // end of form array methods

  formSubmit(){
    if(!this.isEdit){
      console.log("strt adding");

      this.productService.AddItem(this.itemForm.value).subscribe(res=>{
        this.getAllProducts();
        this.clearForm()

      },err=>{
        console.log(err);
      })
    }else{
      console.log('start edit', this.itemToEdit.id);
      let id = this.itemToEdit.id

        let originalItem = {
          id:this.itemToEdit.id,
          name:this.itemForm.get('name')?.value ,
          imageUrl:this.itemForm.get('imageUrl')?.value ,
          price:this.itemForm.get('price')?.value ,
          prices:this.itemForm.get('Prices')?.value ,
        }

      this.productService.updateItem(originalItem, id).subscribe(res=>{
       this.getAllProducts();
       this.clearForm()

      },err=>{
        console.log(err);

      })

      this.isEdit=false
    }
    this.getAllProducts();
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


  //////////
  editItem(item:IItem){
    this.isEdit=true;
    this.itemToEdit = item
    this.createForm();
    for(let i=0; i < item.prices.length-1; i++){
      this.addNewPrice()
    }
    this.itemForm.patchValue(item);
    setTimeout(()=>{    for(let i=0; i < this.Prices.controls.length; i++){
      this.Prices.controls[i].patchValue(item.prices[i])
    }},100)

    this.itemForm.markAsPristine();

  }

  clearForm(){
    this.itemForm.reset()
    this.isEdit=false

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
      this.getAllProducts();

    },err=>{
      console.log(err);

    })
  }

  // jqueryTest(){


  //   // var pricesIndex=1;
  //   // $(document).on('click', '.add-size', function(){
  //   //     var size = $('div[for="sizes"]:first').clone();

  //   //     size.find('.add-size').remove();
  //   //     size.find('.sname').removeAttr("formControlName").attr("formControlName",`sizeName`)
  //   //     size.find('.sprice').removeAttr("formControlName").attr("formControlName",`sizePrice`)
  //   //     $('#frmItem .modal-body').append(size);
  //   //     size.find('.fmgroup').removeAttr("formGroupName").attr("formGroupName",`${pricesIndex}`)
  //   //     pricesIndex++;
  //   // });
  //   // $(document).on('click', '.remove-size', function () {
  //   //     $(this).closest('div[for="sizes"]').remove();
  //   // });
  // }


}
