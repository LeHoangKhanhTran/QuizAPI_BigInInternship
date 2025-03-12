using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Record_RecordID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Question_QuestionID",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTopic_Question_QuestionsID",
                table: "QuestionTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTopic_Topic_TopicsID",
                table: "QuestionTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_Topic_TopicID",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choice",
                table: "Choice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Record",
                newName: "Records");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Choice",
                newName: "Choices");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Record_TopicID",
                table: "Records",
                newName: "IX_Records_TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_QuestionID",
                table: "Choices",
                newName: "IX_Choices_QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_RecordID",
                table: "Answers",
                newName: "IX_Answers_RecordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choices",
                table: "Choices",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Records_RecordID",
                table: "Answers",
                column: "RecordID",
                principalTable: "Records",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionID",
                table: "Choices",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTopic_Questions_QuestionsID",
                table: "QuestionTopic",
                column: "QuestionsID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTopic_Topics_TopicsID",
                table: "QuestionTopic",
                column: "TopicsID",
                principalTable: "Topics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Topics_TopicID",
                table: "Records",
                column: "TopicID",
                principalTable: "Topics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Records_RecordID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionID",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTopic_Questions_QuestionsID",
                table: "QuestionTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTopic_Topics_TopicsID",
                table: "QuestionTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Topics_TopicID",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Choices",
                table: "Choices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "Records",
                newName: "Record");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Choices",
                newName: "Choice");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Records_TopicID",
                table: "Record",
                newName: "IX_Record_TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_Choices_QuestionID",
                table: "Choice",
                newName: "IX_Choice_QuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_RecordID",
                table: "Answer",
                newName: "IX_Answer_RecordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Choice",
                table: "Choice",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Record_RecordID",
                table: "Answer",
                column: "RecordID",
                principalTable: "Record",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Question_QuestionID",
                table: "Choice",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTopic_Question_QuestionsID",
                table: "QuestionTopic",
                column: "QuestionsID",
                principalTable: "Question",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTopic_Topic_TopicsID",
                table: "QuestionTopic",
                column: "TopicsID",
                principalTable: "Topic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Topic_TopicID",
                table: "Record",
                column: "TopicID",
                principalTable: "Topic",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
