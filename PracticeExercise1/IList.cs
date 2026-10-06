namespace PracticeExercise1;

public interface IList
{
	void Append(int value);
	void Prepend(int value);

	void InsertAfter(int newValue, int existingValue);
	void InsertAt(int value, int index);

	void Remove(int value);
	void RemoveAt(int index);

	int? First { get; }
	int? Last { get; }

	bool IsEmpty { get; }
	int Length { get; }

	int FirstIndexOf(int value);
	bool Contains(int value);

	void Clear();
	IList Reverse();

	int? Get(int index);
}


