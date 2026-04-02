import { Component } from '@angular/core';
import { CommentService } from '../../_services/comment-service';
import { CommentDto } from '../../_models/commentDto';
import { SweetalertService } from '../../_services/sweetalert-service';
declare const alertify:any;

@Component({
  selector: 'app-comment',
  standalone: false,
  templateUrl: './comment.html',
  styleUrl: './comment.css',
})
export class Comment {
  constructor(private commentService:CommentService, private swal: SweetalertService){
    this.getComments();
  }

  comments: CommentDto[];
  errors: any=[];

    getComments(){
      this.commentService.getAll().subscribe({
        next: result=>this.comments = result.data,
        error: result=>console.log(result)
      })
    }

    async deleteComment(id){

      const isConfirmed = await this.swal.areYouSure();

      if(isConfirmed){
        this.commentService.delete(id).subscribe({
          error: result=> {console.error(result.error);
            alertify.error("An Error Occured!")
          },
          complete: ()=> {alertify.success("Comment Deleted!");
            this.getComments();
          }
        })
      }
      else{
        console.log("Delete Reverted")
      }
    }
}
