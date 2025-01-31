﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkDotNet.Blog.Domain;

public class BlogPost : Entity
{
    private BlogPost()
    {
    }

    public string Title { get; private set; }

    public string ShortDescription { get; private set; }

    public string Content { get; private set; }

    public string PreviewImageUrl { get; private set; }

    public string PreviewImageUrlFallback { get; private set; }

    public DateTime UpdatedDate { get; private set; }

    public virtual ICollection<Tag> Tags { get; private set; }

    public bool IsPublished { get; set; }

    public int Likes { get; set; }

    public static BlogPost Create(
        string title,
        string shortDescription,
        string content,
        string previewImageUrl,
        bool isPublished,
        DateTime? updatedDate = null,
        IEnumerable<string> tags = null,
        string previewImageUrlFallback = null)
    {
        var blogPost = new BlogPost
        {
            Title = title,
            ShortDescription = shortDescription,
            Content = content,
            UpdatedDate = updatedDate ?? DateTime.Now,
            PreviewImageUrl = previewImageUrl,
            PreviewImageUrlFallback = previewImageUrlFallback,
            IsPublished = isPublished,
            Tags = tags?.Select(Tag.Create).ToList(),
        };

        return blogPost;
    }

    public void Update(BlogPost from)
    {
        if (from == this)
        {
            return;
        }

        Title = from.Title;
        ShortDescription = from.ShortDescription;
        Content = from.Content;
        UpdatedDate = from.UpdatedDate;
        PreviewImageUrl = from.PreviewImageUrl;
        PreviewImageUrlFallback = from.PreviewImageUrlFallback;
        IsPublished = from.IsPublished;
        ReplaceTags(from.Tags);
    }

    private void ReplaceTags(IEnumerable<Tag> tags)
    {
        Tags?.Clear();
        if (Tags == null || tags == null)
        {
            Tags = tags?.ToList();
        }
        else
        {
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}