﻿using BookStore.Core.Entities;
using BookStore.Core.Events;
using BookStore.Core.Services;
using System;
using Xunit;

namespace BookStore.UnitTests.Core.Entities
{
    public class ItemCompletedEmailNotificationHandlerHandle
    {
        [Fact]
        public void ThrowsExceptionGivenNullEventArgument()
        {
            var handler = new ItemCompletedEmailNotificationHandler();

            Exception ex = Assert.Throws<ArgumentNullException>(() => handler.Handle(null));
        }

        [Fact]
        public void DoesNothingGivenEventInstance()
        {
            var handler = new ItemCompletedEmailNotificationHandler();

            handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()));
        }
    }
}
