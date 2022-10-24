using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QuoteEditorBlazor.Data;
using QuoteEditorBlazor.Models;

namespace QuoteEditorBlazor
{
    public class LineItemDateUniquenessValidator : ComponentBase
    {
        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }

        [Parameter]
        public LineItemDate LineItemDate { get; set; }

        [Inject]
        public QuoteEditorContext Context { get; set; }

        public FieldIdentifier DateFieldId
        {
            get
            {
                return CurrentEditContext.Field(nameof(LineItemDate.Date));
            }
        }

        private ValidationMessageStore? messageStore;

        protected override void OnInitialized()
        {
            if (CurrentEditContext is null)
            {
                throw new InvalidOperationException(
                    $"{nameof(LineItemDateUniquenessValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(LineItemDateUniquenessValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            messageStore = new(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += HandleOnValidationRequested;
            CurrentEditContext.OnFieldChanged += HandleOnFieldChanged;
        }

        public void HandleOnValidationRequested(object? sender, ValidationRequestedEventArgs eventArgs)
        {
            messageStore?.Clear();

            if (CurrentEditContext is null) return;

            if (DoesDateAlreadyExists())
            {
                messageStore?.Add(DateFieldId, "This date already exists in this Quote.");
            }

            CurrentEditContext?.NotifyValidationStateChanged();
        }

        public void HandleOnFieldChanged(object? sender, FieldChangedEventArgs eventArgs)
        {
            messageStore?.Clear(eventArgs.FieldIdentifier);
        }

        private bool DoesDateAlreadyExists()
        {
            var match = Context.LineItemDates.FirstOrDefault(
                lid => lid.Date == LineItemDate.Date && lid.QuoteID == LineItemDate.QuoteID
            );

            return (match is not null);
        }
    }
}
