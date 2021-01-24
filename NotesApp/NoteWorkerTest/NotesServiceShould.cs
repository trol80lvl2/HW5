using Moq;
using NotesApp.Services.Abstractions;
using NotesApp.Services.Models;
using NotesApp.Services.Services;
using System;
using Xunit;

namespace NoteWorkerTest
{
    public class NotesServiceShould
    {
        private  Mock<INotesStorage> _notesStorage;
        private  Mock<INoteEvents> _noteEvents;
        private  Mock<NotesService> _notesService;
        bool x = false;

        public NotesServiceShould()
        {
            _notesStorage = new Mock<INotesStorage>();
            _noteEvents = new Mock<INoteEvents>();
            _noteEvents.Setup(x => x.NotifyAdded(It.IsAny<Note>(), It.IsAny<int>())).Callback(() => x = true);
            _notesService = new Mock<NotesService>(new object[] { _notesStorage.Object, _noteEvents.Object });
            //_notesService.Object.
        }

        [Fact]
        public void AddNullNote()
        {
            Assert.Throws<ArgumentNullException>(() => _notesService.Object.AddNote(null, It.IsAny<int>()));
        }
        [Fact]
        public void EventHandleAdded()
        {
            Note note = new Note();
            _notesService.Object.AddNote(note, It.IsAny<int>());
            Assert.True(x);
        }
        [Fact]
        public void EventHandleNotAdded()
        {
            try
            {
                _notesService.Object.AddNote(null, It.IsAny<int>());
            }
            catch (ArgumentNullException) {  }
            Assert.False(x);
        }
    }
}
