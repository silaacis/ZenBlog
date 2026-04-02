import { SubCommentService } from './../../_services/sub-comment-service';
import { Component } from '@angular/core';
import { SubCommentDto } from '../../_models/subCommentDto';
import { SweetalertService } from '../../_services/sweetalert-service';
import { DatePipe } from '@angular/common';
declare const alertify: any;

@Component({
  selector: 'app-sub-comment',
  standalone: false,
  templateUrl: './sub-comment.html',
  styleUrl: './sub-comment.css',
})
export class SubComment {
constructor(private subCommentService:SubCommentService, private swal: SweetalertService){
    this.getSubComments();
  }

  subComments: SubCommentDto[];
  errors: any=[];

    getSubComments(){
      this.subCommentService.getAll().subscribe({
        next: result=>this.subComments = result.data,
        error: result=>console.log(result)
      })
    }

    async deleteSubComment(id){

      const isConfirmed = await this.swal.areYouSure();

      if(isConfirmed){
        this.subCommentService.delete(id).subscribe({
          error: result=> {console.error(result.error);
            alertify.error("An Error Occured!")
          },
          complete: ()=> {alertify.success("SubComment Deleted!");
            this.getSubComments();
          }
        })
      }
      else{
        console.log("Delete Reverted")
      }
    }
}
