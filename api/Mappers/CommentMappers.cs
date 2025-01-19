using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto toCommentDto(this Comment commentModel) {
            return new CommentDto{
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }

        public static Comment toCommentFromCreateDto(this CreateCommentRequestDto commentDto, int stockId) {
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }

        public static Comment toCommentFromUpdateDto(this UpdateCommentRequestDto commentDto) {
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }
    }
}